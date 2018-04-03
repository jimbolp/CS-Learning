<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8" />
    <title>Numbers in Reversed Order</title>
</head>
<body>
    <?php
    function isNull($char){
        if($char == ' ')
            return false;
        return true;
    }
    if (isset($_GET['numbers']) && isset($_GET['delimiter'])) {
        $delimiter = $_GET['delimiter'];
        $nums = array_filter(array_map('trim', explode($delimiter, $_GET['numbers'])));

        for ($i = count($nums)-1; $i >= 0; $i--) {
            if($nums[$i] != " ") {
                echo "$nums[$i]<br>";
            }
        }
    }
    else{ ?>
    <form>
        <textarea name="numbers"></textarea>
        <input type="text" name="delimiter" />
        <input type="submit" />
    </form>
    <?php }?>
</body>
</html>