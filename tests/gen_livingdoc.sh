#!/usr/bin/env bash
set -euo pipefail
cd "$(dirname "$0")"

ASM="bin/Debug/net9.0/tests.dll"
JSON="bin/Debug/net9.0/TestExecution.json"

if [[ ! -f "$ASM" ]]; then
  echo "❌ tests.dll not found. Run 'dotnet build' or 'dotnet test' first."; exit 1
fi
if [[ ! -f "$JSON" ]]; then
  echo "❌ TestExecution.json not found. Ensure SpecFlow.Plus.LivingDocPlugin is installed and re-run tests."; exit 1
fi

livingdoc test-assembly "$ASM" --output "LivingDoc.html" --test-execution-json "$JSON"
echo "✅ LivingDoc created at $(pwd)/LivingDoc.html"
