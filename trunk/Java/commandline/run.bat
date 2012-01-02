SET current_path=%~dp0
cd %current_path%
set classpath=./;F:\04_monkey\05_sample\trunk\Java\libs\monkey-core-0.1.0.jar;F:\04_monkey\05_sample\trunk\Java\libs\monkey-runner-0.1.jar;F:\04_monkey\05_sample\trunk\Java\libs\monkey-0.1.0.jar;F:\04_monkey\05_sample\trunk\Java\libs\servlet-api.jar;F:\04_monkey\05_sample\trunk\Java\libs\quartz-1.8.4.jar;F:\04_monkey\05_sample\trunk\Java\libs\monkey-arcgis-0.1.jar;%classpath%

java -Djava.ext.dirs="D:\Program Files\ArcGIS\Desktop10.0\java\lib;../libs" -jar ../libs/monkey-runner-0.1.jar run file ../config/models/arcsample.xml ../../data/shp/Road_L.shp ../../data/Default.gdb/RoadLBuffer "5 Kilometers" NAME ../../data/shp/Lake_R.shp ../../data/Default.gdb/RoadLakeClip
pause ...