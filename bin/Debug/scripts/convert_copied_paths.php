<?php
// 读取输入

$input = base64_decode(file_get_contents('php://stdin'));

// 开始处理

$str = str_replace("\r\n", "\n", $input);
$lines = explode("\n", trim($str));

$output = "";
foreach ($lines as $line) {
    $output .= str_replace('\\', '/', trim($line, '"')) . "\r\n";
}

// 输出结果

echo base64_encode($output);

?>
