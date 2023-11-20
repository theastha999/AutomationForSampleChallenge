function list_child_processes () {
    local ppid=$1;
    local current_children=$(pgrep -P $ppid);
    local local_child;
    if [ $? -eq 0 ];
    then
        for current_child in $current_children
        do
          local_child=$current_child;
          list_child_processes $local_child;
          echo $local_child;
        done;
    else
      return 0;
    fi;
}

ps 32476;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 32476 > /dev/null;
done;

for child in $(list_child_processes 32500);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/astha.jaiswal/Documents/GitHub/AutomationTestSample/AutomationTestSample/bin/Debug/net6.0/139fff5a62644bfdb633df8b53a0c2cd.sh;
