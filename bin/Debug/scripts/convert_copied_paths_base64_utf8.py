import sys
import base64

'''
[ClipboardAutoProcessor]
inputEncoding = base64_utf8
outputEncoding = base64_utf8
'''

# Read input

input = base64.b64decode(sys.stdin.read()).decode('utf-8')

# Process

input = input.replace("\r\n", "\n")
lines = input.strip().split("\n")

output = ""
for line in lines:
    output += line.strip('"').replace("\\", "/") + "\r\n"

if not input.endswith("\n"):
    output = output.rstrip()

# Output result

print(base64.b64encode(output.encode('utf-8')).decode('ascii'))
