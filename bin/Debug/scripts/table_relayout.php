<?php
// 读取输入

$input = base64_decode(file_get_contents('php://stdin'));

// 处理

$rows = parse_table($input);

$output = "/*\r\n";
$output .= make_table($rows);
$output .= " */\r\n";

// 输出结果

echo base64_encode($output);


function parse_table($table) {
    $rows = array();

    $lines = explode("\n", $table);
    foreach ($lines as $line) {
        $line = trim($line);
        if ($line == '') {
            continue;
        }

        if (trim($line, "*+-| \t\r\n") == '') {
            continue;
        }

        $cols = explode('|', trim($line, "*| \t\r\n"));

        $rows[] = array_map('trim', $cols);
    }

    return $rows;
}

function make_table($rows, $prefix = ' * ') {
    if (!count($rows)) {
        return '';
    }

    $cols_count = 0;
    foreach ($rows as $cols) {
        if (count($cols) > $cols_count) {
            $cols_count = count($cols);
        }
    }

    $cols_width = array();
    for ($i = 0; $i < $cols_count; $i++) {
        $cols_width[$i] = 0;
    }

    for ($i = 0; $i < count($rows); $i++) {
        while (count($rows[$i]) < $cols_count) {
            array_push($rows[$i], '');
        }
    }

    for ($i = 0; $i < count($rows); $i++) {
        $cols = $rows[$i];

        for ($j = 0; $j < $cols_count; $j++) {
            $width = mb_strwidth($cols[$j], 'UTF-8');

            if ($width > $cols_width[$j]) {
                $cols_width[$j] = $width;
            }
        }
    }

    for ($j = 0; $j < $cols_count; $j++) {
        $cols_width[$j] = (($j == 0) ? mb_strwidth($prefix, 'UTF-8') : 0) + 2 + $cols_width[$j] + 1;

        if (($cols_width[$j] % 4) != 0) {
            $cols_width[$j] += (4 - ($cols_width[$j] % 4));
        }
    }

    $separator_line = '';
    for ($j = 0; $j < $cols_count; $j++) {
        $separator_line .= mb_str_pad((($j == 0) ? $prefix : '') . '+-', $cols_width[$j], '-');
    }
    $separator_line .= "+\r\n";

    $result = '';
    $result .= $separator_line;
    for ($i = 0; $i < count($rows); $i++) {
        $cols = $rows[$i];

        for ($j = 0; $j < $cols_count; $j++) {
            $result .= mb_str_pad((($j == 0) ? $prefix : '') . '| ' . $cols[$j] . ' ', $cols_width[$j], ' ');
        }
        $result .= "|\r\n";

        if ($i == 0) {
            $result .= $separator_line;
        }
    }
    $result .= $separator_line;

    return $result;
}

function mb_str_pad($input, $pad_length, $pad_string) {
    return $input . str_repeat($pad_string, $pad_length - mb_strwidth($input, 'UTF-8'));
}


?>
