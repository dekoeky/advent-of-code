#!/usr/bin/env bash
set -euo pipefail

HTML_FILE="${1:-events.html}"

if [[ ! -f "$HTML_FILE" ]]; then
    echo "ERROR: File not found: $HTML_FILE" >&2
    exit 1
fi

rows=$(grep -oP '<div class="eventlist-event">.*?</div>' "$HTML_FILE")

printf "{\n  \"years\": [\n"

total_achieved=0
total_achievable=0
first=1

while read -r row; do
    [[ -z "$row" ]] && continue

    year=$(echo "$row" | grep -oP '\[\K[0-9]{4}(?=\])')

    achieved=$(echo "$row" \
        | grep -oP 'class="star-count">\K[0-9]+(?=\*)' || echo "null")

    achievable=$(echo "$row" \
        | grep -oP 'class="quiet">/\s*\K[0-9]+(?=\*)' || echo "null")

    if [[ "$achieved" != "null" ]]; then
        total_achieved=$((total_achieved + achieved))
    fi
    if [[ "$achievable" != "null" ]]; then
        total_achievable=$((total_achievable + achievable))
    fi

    if [[ $first -eq 0 ]]; then
        printf ",\n"
    fi
    first=0

    printf "    { \"year\": $year, \"achieved\": $achieved, \"achievable\": $achievable }"

done <<< "$rows"

printf "\n  ],"

# Empty line for visual separation
printf "\n"

# Print "Total" json block
# Remark: This achievable does not include the years that are not started yet!
printf "\n  \"total\": {"
printf "\n    \"achieved\": $total_achieved,"
printf "\n    \"achievable\": $total_achievable"
printf "\n  }"
printf "\n}"

# echo
# echo "Total achieved: $total_achieved"
# echo "Total achievable: $total_achievable"