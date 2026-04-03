#!/usr/bin/env bash
set -euo pipefail

SUMMARY_JSON="${1:-star-tracking/data/json/events.json}"

{
  # echo "# ⭐ Advent of Code Progress"
  # echo

  # Per-year badges
  jq -r '
    .years[]
    | select(.achieved != null)
    | "[![Advent of Code \(.year)](https://img.shields.io/badge/\(.year)-\(.achieved)_/_\(.achievable)_%E2%AD%90-blue?style=for-the-badge)](https://adventofcode.com/\(.year))  "
  ' "$SUMMARY_JSON"

  echo
  jq -r '
    "[![Total Stars](https://img.shields.io/badge/Total-\(.total.achieved)_/_\(.total.achievable)_%E2%AD%90-purple?style=for-the-badge)](https://adventofcode.com/events)  "
  ' "$SUMMARY_JSON"
}