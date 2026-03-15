#!/usr/bin/env bash
set -euo pipefail

DATA_DIR="star-tracking/data"
HTML_DIR="${DATA_DIR}/html"
JSON_DIR="${DATA_DIR}/json"

EVENTS_JSON="${JSON_DIR}/events.json"
SUMMARY_JSON="${JSON_DIR}/summary.json"

if [[ ! -f "$EVENTS_JSON" ]]; then
    echo "ERROR: $EVENTS_JSON not found. Run download.sh first." >&2
    exit 1
fi

# Extract the available years from the events.json file
YEARS=$(jq -r '.years[].year' "$EVENTS_JSON")

echo "==> Parsing all years..."

TMP_JSON_LIST="["
first=1

for YEAR in $YEARS; do
    YEAR_HTML="${HTML_DIR}/${YEAR}.html"

    if [[ ! -f "$YEAR_HTML" ]]; then
        echo "WARNING: Missing HTML for year $YEAR, skipping." >&2
        continue
    fi

    echo "    Parsing year $YEAR..."
    YEAR_JSON=$(./star-tracking/scripts/parse-year.sh "$YEAR_HTML")

    if [[ $first -eq 0 ]]; then
        TMP_JSON_LIST="${TMP_JSON_LIST},"
    fi
    first=0

    TMP_JSON_LIST="${TMP_JSON_LIST}{\"year\": ${YEAR}, \"days\": ${YEAR_JSON#*\"days\": }"
done

TMP_JSON_LIST="${TMP_JSON_LIST}]"

echo "==> Building combined summary JSON..."

echo "$TMP_JSON_LIST" | jq '
  map(
      .achieved = ( .days | map(.achieved) | add ),
      .achievable = ( .days | map(.achievable) | add )
  ) as $years
  |
  {
    years: $years,
    totalAchieved: ($years | map(.achieved) | add),
    totalAchievable: ($years | map(.achievable) | add)
  }
' > "$SUMMARY_JSON"

echo "==> DONE!"
echo "Summary written to: $SUMMARY_JSON"