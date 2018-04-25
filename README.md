<h2>Removes timestamps from GPX and KML files, and as an afterthought, converts KML to GPX and vice versa using GPSBabel</h2>

Project was mainly just an excuse to get familiar with Github, but...

Scenario: You have a bunch of gpx tracks and want to view them all at once on Google Earth. You add one, the time slider appears and the track appears. You try to add another, and the first one disappears. 

There may be settings in GE to change that behavior, but my solution was to just strip out some of the timestamp tags, as I don't need them for what I'm doing.

The afterthought...<br/>
Another scenario:  You create a bunch of "paths" on Google Earth, saving them as KML files, and intend to upload them to your GPS device.
Your gps software doesn't know what a KML file is, so they need to be converted using GPSBabel, which requires you to process them one at a time, and manually change the destination file name.  
GPSBabel will let you run it from the command line, so I just created something to let me drag and drop mutliple files, and have them process all at once, using GPSBabel in the background, keeping the source and destination folder the same.

You must install GPSBabel (https://www.gpsbabel.org/), and enter a valid path to the gpsbabel.exe file for the program to work.

The program appears to work for my purposes, but I'm no expert in this field, and it was was thrown together without a lot of testing, so you shouldn't use this for anything critical.
