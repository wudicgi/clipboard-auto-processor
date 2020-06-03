'use strict';

// 读取输入

process.stdin.resume();
process.stdin.setEncoding('utf8');

let inputData = "";
process.stdin.on('data', (inputLine) => {
    inputData += inputLine;
});

process.stdin.on('end', () => {
    let inputDataBuffer = Buffer.from(inputData, 'base64');
    let inputText = inputDataBuffer.toString('utf-8');

    main(inputText);
});

function main(inputText) {
    // 开始处理

    let str = inputText.replace(/\r\n/g, "\n");
    let lines = str.trim().split("\n");

    let outputText = "";
    lines.forEach(line => {
        outputText += line.replace(/^[\"]+|[\"]+$/g, "").replace(/\\/g, "/") + "\r\n";
    });

    // 输出结果

    console.log(Buffer.from(outputText).toString('base64'));
}
