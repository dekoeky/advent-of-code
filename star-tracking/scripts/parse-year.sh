#!/usr/bin/env bash
set -euo pipefail

HTML_FILE="${1:-year.html}"

if [[ ! -f "$HTML_FILE" ]]; then
    echo "ERROR: File not found: $HTML_FILE" >&2
    exit 1
fi

# Extract all calendar day <a> tags
# Works for both 2015 & 2025 HTML
# rows=$(grep -oP '<a[^>]*calendar-day[0-9]+' "$HTML_FILE")

# To Match the whole <a ...>...</a> block for each day, we can use a more complex regex with a non-greedy match:
# rows=$(grep -oP '(?s)<a\b[^>]*\bcalendar-day[0-9]{1,2}\b[^>]*>.*?</a>' "$HTML_FILE")

# Match the opening tag
rows=$(grep -oP '<a\b[^>]*\bcalendar-day[0-9]{1,2}\b[^>]*>' "$HTML_FILE")

echo "{"
echo "  \"days\": ["

first=1

while read -r row; do
    [[ -z "$row" ]] && continue
    
    # Extract the day number from "calendar-dayNN"
    day=$(echo "$row" | grep -oP 'calendar-day\K[0-9]+')
    
    # The achievable stars are always 2
    achievable=2

    # Depending on the presence of these tags, we can find the achieved stars
    if echo "$row" | grep -q 'calendar-verycomplete'; then
        achieved=2
    elif echo "$row" | grep -q 'calendar-complete'; then
        achieved=1
    else
        achieved=0
    fi

    # JSON entry
    if [[ $first -eq 0 ]]; then echo ","; fi
    first=0

    echo -n "    { \"day\": $day, \"achieved\": $achieved, \"achievable\": $achievable }"

done <<< "$rows"

printf "\n  ]"
printf "\n}"