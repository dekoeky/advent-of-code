---
name: extract-aoc-puzzle-info
user-invocable: true
description: Extract puzzle information, input, and text from an Advent of Code day page and create a markdown file. Use when: extracting AOC puzzle details for a specific day.
---

To extract puzzle information from an Advent of Code day page (e.g., https://adventofcode.com/2023/day/16) and create a nice markdown file:

1. Use the fetch_webpage tool to retrieve the content from the provided URL, querying for the puzzle title, description, part 1 and part 2 instructions, example inputs, and any other relevant text.

2. Check if the corresponding year/day folder exists in the advent-of-code/{year}/ directory. If not, create it (e.g., advent-of-code/2023/Day16/).

3. Create a README.md file in the day folder with the extracted information formatted nicely in Markdown, including:
   - Title
   - Description
   - Example input (if available)
   - Rules and explanations
   - Part 1 question
   - Note for Part 2 (as it's revealed after solving)

4. If the actual puzzle input is needed, note that it requires login and personal session; otherwise, use the example.

Ensure the markdown is clean and readable.