<?php
// 读取输入

$input = base64_decode(file_get_contents('php://stdin'));

// 处理

$text = trim($input);

$text = str_replace("\r\n", "\n", $text);
$text = str_replace("\n", "", $text);
$text = remove_illegal_characters($text);
$text = adjust_spaces($text);

$output = trim($text);

// 输出结果

echo base64_encode($output);


/**
 * 去除多余的不正常字符
 *
 * ESP8266 的 PDF 技术文档中，有一些多余的 Unicode 康熙部首 (2F00-2FDF) 和中日韩兼容表意文字 (F900-FAFF)
 * 等范围内的字符，如 U+2F63 (⽣, 生), U+2F83 (⾃, 自), U+F976 (略, 略) 等，需要去除。
 */
function remove_illegal_characters($str) {
    $chars = preg_split('//u', $str, -1, PREG_SPLIT_NO_EMPTY);

    $result = '';
    foreach ($chars as $char) {
        $char_gbk = mb_convert_encoding($char, 'GBK', 'UTF-8');
        if (($char != '?') && ($char_gbk == '?')) {
            continue;
        }

        $char_converted_back = mb_convert_encoding($char_gbk, 'UTF-8', 'GBK');
        if ($char_converted_back != $char) {
            continue;
        }

        $result .= $char;
    }

    return $result;
}

/**
 * 调整空格
 */
function adjust_spaces($str) {
    // 将连续的多个空格替换为一个
    while (strpos($str, '  ') !== false) {
        $str = str_replace('  ', ' ', $str);
    }

    // 在汉字与英文、数字、下划线之间添加一个空格
    // https://www.hangge.com/blog/cache/detail_1642.html
    $str = preg_replace('/([\x{4e00}-\x{9fa5}]+)([A-Za-z0-9_]+)/u', '$1 $2', $str);
    $str = preg_replace('/([A-Za-z0-9_]+)([\x{4e00}-\x{9fa5}]+)/u', '$1 $2', $str);

    return $str;
}

?>
