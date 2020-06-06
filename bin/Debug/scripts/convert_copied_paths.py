import sys
import base64

# encodingType = "base64_utf8"
encodingType = "systemDefault"

# 读取输入

if encodingType == "base64_utf8":
    inputText = base64.b64decode(sys.stdin.read()).decode('utf-8')
else:
    inputText = sys.stdin.read()

# 开始处理

str = inputText.replace("\r\n", "\n")
lines = str.strip().split("\n")

outputText = ""
for line in lines:
    outputText += line.strip('"').replace("\\", "/") + "\r\n"

# 输出结果

if encodingType == "base64_utf8":
    print(base64.b64encode(outputText.encode('utf-8')).decode('ascii'))
else:
    print(outputText.replace("\r\n", "\n"), end = '')
