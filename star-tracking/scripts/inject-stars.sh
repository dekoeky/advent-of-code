#!/usr/bin/env bash
set -euo pipefail

README="${1:-README.md}"

START="<!-- PROGRESS-MARKDOWN-PLACEHOLDER-START -->"
END="<!-- PROGRESS-MARKDOWN-PLACEHOLDER-END -->"

content="$(cat "$README")"
generated="$(cat -)"        # read from stdin

# Read all content of the original markdown, before and after the placeholder
before="$(printf "%s" "$content" | sed -n "1,/$START/p")"
after="$(printf "%s" "$content" | sed -n "/$END/,\$p")"

before="${before%$START*}$START"
after="$END${after#*$END}"

printf "%s\n" "$before"
printf "%s\n" "$generated"
printf "%s\n" "$after"