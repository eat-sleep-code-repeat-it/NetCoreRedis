# Redis Server on Windows 10 with WSL

## set up WSL with Ubuntu

1. with powershell, enable Windows Subsystem for Linux (WSL):

```bash
Enable-WindowsOptionalFeature -Online -FeatureName Microsoft-Windows-Subsystem-Linux
```

2. Reboot Windows after making the change—note that you only need to do this one time
3. Download and install one of the supported Linux distros from the Microsoft Store.
4. Ubuntu 18.04
5. Some commands in WSL

- ALT+ENTER to make WSL bash full screen
- CTRL + MOUSE SCROLL to zoom-in/out
- SHIFT + MOUSE SCROLL to scroll up/down
- CTRL+SHIFT+MOUSE SCROLL to change transparency of bach window
- ls /mnt to list all mounted drive in windows
- code . to open code in windows from WSL

```bash
lsb-release -a
pwd
df -h 
// windows folder
cd /mnt/c
sudo apt install htop
```

## Install and Test Redis

```bash
$ sudo apt-get update
$ sudo apt-get upgrade
$ sudo apt-get install redis-server
$ redis-cli -v

// restart
$ sudo service redis-server restart
$ sudo service redis-server stop

$ redis-cli
127.0.0.1:6379> set user:1 "TestUser"
127.0.0.1:6379> get user:1
```

## Reference

- http://hanselman.com/windows10.
