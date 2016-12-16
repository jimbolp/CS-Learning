<!DOCTYPE html>
<html>
<head>
    <title>Convert</title>
</head>

<body>
<?php
function celsiusToFahrenheit(float $degrees) : float
{
    return $degrees * 1.8 + 32;
}
function fahrenheitToCelsius(float $degrees) : float
{
    return ($degrees - 32) / 1.8;
}
?>
<form>
    Celsius: <input type="number" name="celsius" />
    <input type="submit" value="Convert" />
    <?php
    if(isset($_GET['celsius']) && $_GET['celsius'] != ''){
        $degreesCelsius = $_GET['celsius'];
        echo "$degreesCelsius &deg;C = " . celsiusToFahrenheit($degreesCelsius) . " &deg;F";
    }?>
    <br>
    </form>
    <form>
    Fahrenheit: <input type="number" name="fahrenheit" />
    <input type="submit" value="Convert" />
    <?php
    if(isset($_GET['fahrenheit']) && $_GET['fahrenheit'] != ''){
        $degreesFahrenheit = $_GET['fahrenheit'];
        echo "$degreesFahrenheit &deg;F = " . fahrenheitToCelsius($degreesFahrenheit) . " &deg;C";
    }
    ?>
    <br>
</form>


</body>
</html>