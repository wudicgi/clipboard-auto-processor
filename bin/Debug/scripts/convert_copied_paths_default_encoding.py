import sys

'''
[ClipboardAutoProcessor]
inputEncoding = systemDefault
outputEncoding = systemDefault
'''

# 读取输入

inputText = sys.stdin.read()

# 开始处理

str = inputText.replace("\r\n", "\n")
lines = str.strip().split("\n")

outputText = ""
for line in lines:
    outputText += line.strip('"').replace("\\", "/") + "\r\n"

# 输出结果

print(outputText.replace("\r\n", "\n"), end = '')
