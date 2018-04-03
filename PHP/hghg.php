<!DOCTYPE html>
<html>
<head>
    <title>Hello</title>
</head>

<body>

<h1>This is my list!</h1>
<!-- test 1 -->
<ul>
    <?php
    for($i = 1; $i<=10;$i++){
        printf("<li>Hello %d "."Blq</li>",$i);
    }
    ?>
</ul>

<?php
echo "Hello PHP!";
?>
<!-- test 2 -->
<ul>
    <?php
    for($i = 1; $i <= 20; ++$i){
        if($i % 2 == 0){
            echo "<li><span style='color: green'><b>Number $i</b></span></li>";
        }
        else{
            echo "<li><span style='color: blue'><b>Number $i</b></span></li>";
        }
    }
    ?>
</ul>
<!-- test 3 -->

<?php
echo "<br>";
$month = date("m");
if($month >= 6 && $month <= 8){
    echo "It is summer";
}
else
    echo "Not summer";
?>
<br>
<!-- test 4 -->

<?php
$arr = [3, 4, 66, 55,101, 100, 203, 5, 7, 88];
foreach ($arr as $el){
    if($el % 2 == 0)
        echo "<div style='color: green' align='center'><b>Element $el</b></div><br>";
    else
        echo "<div style='color: blue' align='center'><b>Element $el</b></div><br>";
}
var_dump($arr);
?>
<br>
<!-- test 5 -->

<?php
for($red = 0; $red <= 255; $red += 51){
    for($green = 0; $green <= 255; $green += 51){
        for($blue = 0; $blue <= 255; $blue += 51){
            $color = "rgb($red, $green, $blue)";
            ?>
            <div style='background:<?=$color?>;
                display: inline-block;
                width: 120px;
                padding: 5px;
                margin: 5px'><?=$color?></div>
        <?php }
    }
}
?>
<br>


</body>
</html>