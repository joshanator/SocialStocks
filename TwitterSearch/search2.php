<?php
//authentication
$app_key = 'DmmHdgll6QHDxLzHifzSsD33r';
$app_token = 'UqLOEUa0c50i8riUN0lxOICy75fmTQqDcTa9sBboewqrCoFxAz';
$api_base = 'https://api.twitter.com/';
$bearer_token_creds = base64_encode($app_key.':'.$app_token);
$opts = array(
  'http'=>array(
    'method' => 'POST',
    'header' => 'Authorization: Basic '.$bearer_token_creds."\r\n".
               'Content-Type: application/x-www-form-urlencoded;charset=UTF-8',
    'content' => 'grant_type=client_credentials'
  )
);
$context = stream_context_create($opts);
$json = file_get_contents($api_base.'oauth2/token',false,$context);
$result = json_decode($json,true);
if (!is_array($result) || !isset($result['token_type']) || !isset($result['access_token'])) {
  die("Something went wrong. This isn't a valid array: ".$json);
}
if ($result['token_type'] !== "bearer") {
  die("Invalid token type. Twitter says we need to make sure this is a bearer.");
}
$bearer_token = $result['access_token'];
$opts = array(
  'http'=>array(
    'method' => 'GET',
    'header' => 'Authorization: Bearer '.$bearer_token
  )
);
//search query
$context = stream_context_create($opts);

$json = file_get_contents($api_base . '1.1/statuses/user_timeline.json?count=200&trim_user=true&exclude_replies=true&screen_name=' . $_GET['user'] ,false,$context);
$tweets = json_decode($json,true);

for($i = 0; $i < 10; $i++) {
	$json = file_get_contents($api_base . '1.1/statuses/user_timeline.json?count=200&trim_user=true&exclude_replies=true&max_id=' . $tweets[count($tweets) - 1]['id_str'] . '&screen_name=' . $_GET['user'] ,false,$context);
	$temp = $tweets;
	$tweets = array_merge($temp, json_decode($json,true));
}



$keyword=$_GET['q'];
$dates = array();
for($i = 0; $i < count($tweets); $i++) {
	//Sat Feb 18 13:52:37 +0000 2017
	$date = DateTime::createFromFormat('D M d H:i:s O Y', $tweets[$i]['created_at']);

	if(strpos(strtoupper($tweets[$i]['text']), strtoupper($keyword)) !== false) {
		if(array_key_exists($date->format('mdY'), $dates))
			$dates[$date->format('mdY')]++;
		else
			$dates[$date->format('mdY')] = 1;
		//echo $tweets['statuses'][$i]['text'] . "\r\n";
	}
}

echo json_encode($dates);
?>