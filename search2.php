<?php
	$json = file_get_contents('https://whatthetrend.com/articles?q=ford');

	$tweets = json_decode($json,true);

	print_r($tweets);

	echo "---------------------------------------\r\n";
	$dates = array();
	for($i = 0; $i < count($tweets['articles']); $i++) {
		$date = DateTime::createFromFormat('D, d M Y H:i:s O', $tweets['articles'][$i]['date']);
		if(array_key_exists($date->format('Y-M-D'), $dates))
			$dates[$date->format('Y-M-D')]++;
		else
			$dates[$date->format('Y-M-D')] = 1;
		echo $tweets['articles'][$i]['text'] . "\r\n";
	}

	echo "---------------------------------------\r\n";
	print_r($dates);
?>