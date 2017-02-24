<?php
// 读取输入

$fp = fopen('php://stdin', 'r');
$input = stream_get_contents($fp);
fclose($fp);

$input = base64_decode($input);

// 开始处理

$pos = strpos($input, ':');
if ($pos !== false) {
    $input = substr($input, $pos + 1);
}

$output = preg_replace("/[ \t\r\n\\|]/", "", $input);

// 输出结果

echo base64_encode($output);

?>
