#!/bin/bash

URL="https://adventofcode.com/2015/day/4/input"


AOC_SESSION="${AOC_SESSION:-}"
if [[ -z "$AOC_SESSION" ]]; then
    echo "ERROR: AOC_SESSION token not provided." >&2
    exit 1
fi

STATUS=$(curl -s -o /dev/null -w "%{http_code}" --cookie "session=${AOC_SESSION}" "$URL")

if [ "$STATUS" -eq 200 ]; then
    echo "OK"
    exit 0
else
    echo "NOT OK (status $STATUS)"
    exit 2
fi