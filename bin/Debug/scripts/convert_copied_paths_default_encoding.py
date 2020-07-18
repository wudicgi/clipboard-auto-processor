import sys

'''
[ClipboardAutoProcessor]
inputEncoding = systemDefault
outputEncoding = systemDefault
'''

# Read input

input = sys.stdin.read()

# Process

input = input.replace("\r\n", "\n")
lines = input.strip().split("\n")

output = ""
for line in lines:
    output += line.strip('"').replace("\\", "/") + "\r\n"

if not input.endswith("\n"):
    output = output.rstrip()

# Output result

print(output.replace("\r\n", "\n"), end = '')
