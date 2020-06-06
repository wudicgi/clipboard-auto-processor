import sys
import base64

'''
[ClipboardAutoProcessor]
inputEncoding = base64_utf8
outputEncoding = base64_utf8
'''

# 读取输入

inputText = base64.b64decode(sys.stdin.read()).decode('utf-8')

# 开始处理

str = inputText.replace("\r\n", "\n")
lines = str.strip().split("\n")

outputText = ""
for line in lines:
    outputText += line.strip('"').replace("\\", "/") + "\r\n"

# 输出结果

print(base64.b64encode(outputText.encode('utf-8')).decode('ascii'))
