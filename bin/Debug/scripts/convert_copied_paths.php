<?php
// Read input

$input = base64_decode(file_get_contents('php://stdin'));

// Process

$input = str_replace("\r\n", "\n", $input);
$lines = explode("\n", trim($input));

$output = "";
foreach ($lines as $line) {
    $output .= str_replace('\\', '/', trim($line, '"')) . "\r\n";
}

if (substr($input, -1, 1) != "\n") {
    $output = rtrim($output);
}

// Output result

echo base64_encode($output);

?>
