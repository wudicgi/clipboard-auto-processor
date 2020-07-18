'use strict';

// Read input

process.stdin.resume();
process.stdin.setEncoding('utf8');

let inputData = "";
process.stdin.on('data', (inputLine) => {
    inputData += inputLine;
});

process.stdin.on('end', () => {
    let inputDataBuffer = Buffer.from(inputData, 'base64');
    let input = inputDataBuffer.toString('utf-8');

    main(input);
});

function main(input) {
    // Process

    input = input.replace(/\r\n/g, "\n");
    let lines = input.trim().split("\n");

    let output = "";
    lines.forEach(line => {
        output += line.replace(/^[\"]+|[\"]+$/g, "").replace(/\\/g, "/") + "\r\n";
    });

    if (!input.endsWith("\n")) {
        output = output.trimEnd();
    }

    // Output result

    console.log(Buffer.from(output).toString('base64'));
}
