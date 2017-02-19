<?php

	$tweets = array();
	$dates = array();
	$i = -1;
	$page = 1;
	
	$nextPage = true;
	while($nextPage) {
		$src = new DOMDocument('1.0', 'utf-8');
		$src->formatOutput = true;
		$src->preserveWhiteSpace = false;
		$content = file_get_contents('https://trendogate.com/search/?trend=' . htmlspecialchars($_GET["q"]) . '&page=' . $page);
		@$src->loadHTML($content);
		$xpath = new DOMXPath($src);
		$values=$xpath->query('//td');

		$nextPage = false;
		foreach($values as $value) {
			if($i % 5 == 0) {
				//Tue, 18 Oct 2016 23:50:14
				$tweets[$i] = new DateTime($value->nodeValue);

				if($tweets[$i] != null)
					$nextPage = true;

				if(array_key_exists($tweets[$i]->format('mdY'), $dates))
					$dates[$tweets[$i]->format('mdY')]++;
				else
					$dates[$tweets[$i]->format('mdY')] = 1;
			}
			$i++;
		}
		$page++;
	}

	echo json_encode($dates);


?>