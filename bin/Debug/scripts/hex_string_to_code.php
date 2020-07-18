<?php
// Read input

$input = base64_decode(file_get_contents('php://stdin'));

// Process

define('COUNT_PER_LINE', 16);

$hex_string = trim($input);

$hex_string_length = strlen($hex_string);
if (($hex_string_length % 2) != 0) {
    echo "Wrong length of input hex string: $hex_string_length";
    exit;
}

$output = "";
for ($i = 0; $i < $hex_string_length; $i += 2) {
    $output .= "0x" . strtoupper(substr($hex_string, $i, 2));

    if ((($i / 2) % COUNT_PER_LINE) == (COUNT_PER_LINE - 1)) {
        $output .= ",\r\n";
    } else {
        $output .= ", ";
    }
}

$output = rtrim($output, ", \r\n");

// Output result

echo base64_encode($output);

?>
