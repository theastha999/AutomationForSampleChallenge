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

ps 61553;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 61553 > /dev/null;
done;

for child in $(list_child_processes 61567);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/astha.jaiswal/Documents/GitHub/ChallengeApp/AutomationTestSample/bin/Debug/net6.0/25d2b5c8686f43d488729d527aacfd2c.sh;
