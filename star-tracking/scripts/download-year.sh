#!/usr/bin/env bash
set -euo pipefail

YEAR="$1"
TOKEN="${2:-${AOC_SESSION:-}}"

if [[ -z "$TOKEN" ]]; then
    echo "ERROR: No AoC session token provided." >&2
    echo "Provide it via:" >&2
    echo "  export AOC_SESSION=your_token" >&2
    echo "or:" >&2
    echo "  ./download-year.sh 2025 <token>" >&2
    exit 1
fi

curl -s \
  --cookie "session=${TOKEN}" \
  "https://adventofcode.com/${YEAR}"