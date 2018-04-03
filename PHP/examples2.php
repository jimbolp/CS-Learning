<!DOCTYPE html>
<html>
<head>
    <title>Multiply Numbers</title>
</head>
<body>

<?php
$mysqli = new mysqli('localhost', 'root', '', 'blog');
$mysqli->set_charset('utf8');

if($mysqli->connect_errno)die('Cannot connect to MySQL');

$queryResult = $mysqli->query('SELECT u.id, ifnull(u.full_name, \'Анонимен\') as Name, p.title, p.content from users u
LEFT JOIN posts p on p.user_id = u.ID');
while ($table = $queryResult->fetch_assoc()) {
    echo htmlspecialchars($table['id'] . " " . $table['Name']);
     echo ("<br>");
     echo htmlspecialchars($table['title']);
    echo ("<br>");
    echo htmlspecialchars($table['content']);
    echo "<br>";
}
?>

</body>

</html>