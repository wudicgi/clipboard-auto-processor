<?php
// 读取输入

$fp = fopen('php://stdin', 'r');
$input = stream_get_contents($fp);
fclose($fp);

$input = base64_decode($input);

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
