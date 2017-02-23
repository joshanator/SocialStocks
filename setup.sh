#!/bin/bash
echo "You are about to install the smudge. Please make sure that all"
echo "your changes have been commited."
echo ""

read -r -p "Are you sure? [Y/n] " -n 1
if [[ ! ($REPLY == "Y" || $REPLY == "y") ]]
then
	echo ""
	echo "No changes made."
	exit 0
fi

echo ""
echo "Installing filters..."
git config --remove-section "filter.cleaner"
git config --add filter.cleaner.clean "~/.clean"
git config --add filter.cleaner.smudge "~/.smudge"

cp .smudge ~/.smudge
echo "Installed smudge filter into " ~/.smudge
cp .clean ~/.clean
echo "Installed clean filter into " ~/.clean

echo -ne "Cleaning"
find . -name "*.config" | while read FILENAME
do
	echo -ne "\n" $FILENAME
	[ -f $FILENAME ] && rm $FILENAME | cut -c 2-
	git checkout $FILENAME > nul | cut -c 2-
done
exit 0