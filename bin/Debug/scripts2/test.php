<?php
// 读取输入

$fp = fopen('php://stdin', 'r');
$input = stream_get_contents($fp);
fclose($fp);

$input = base64_decode($input);

// 开始处理

$output = $input;
while (strpos($output, '  ') !== false) {
    $output = str_replace('  ', ' ', $output);
}

// 输出结果

echo base64_encode($output);

?>
