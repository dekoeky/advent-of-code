#!/usr/bin/env bash
set -euo pipefail

AOC_SESSION="${AOC_SESSION:-}"
if [[ -z "$AOC_SESSION" ]]; then
    echo "ERROR: AOC_SESSION token not provided." >&2
    exit 1
fi

DATA_DIR="star-tracking/data"
HTML_DIR="${DATA_DIR}/html"
JSON_DIR="${DATA_DIR}/json"

EVENTS_HTML="${HTML_DIR}/events.html"
EVENTS_JSON="${JSON_DIR}/events.json"

mkdir -p "$HTML_DIR" "$JSON_DIR"

echo "==> Downloading events page..."
./scripts/download-events.sh "$AOC_SESSION" > "$EVENTS_HTML"

echo "==> Parsing events page..."
./scripts/parse-events.sh "$EVENTS_HTML" > "$EVENTS_JSON"

YEARS=$(jq -r '.years[].year' "$EVENTS_JSON")
# echo "==> Available years: $YEARS"

for YEAR in $YEARS; do
    OUTFILE="${HTML_DIR}/${YEAR}.html"
    echo "==> Downloading year $YEAR..."
    ./scripts/download-year.sh "$YEAR" "$AOC_SESSION" > "$OUTFILE"
done

echo "==> Download complete."
echo "HTML files in: $HTML_DIR"
echo "Events JSON:   $EVENTS_JSON"