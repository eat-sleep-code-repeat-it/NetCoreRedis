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

- <b>ALT+ENTER</b> to make WSL bash full screen
- <b>CTRL + MOUSE SCROLL</b> to zoom-in/out
- <b>SHIFT + MOUSE SCROLL</b> to scroll up/down
- <b>CTRL+SHIFT+MOUSE SCROLL</b> to change transparency of bach window
- <b>ls /mnt</b> to list all mounted drive in windows
- <b>code .</b> to open code in windows from WSL
- <b>wsl -l</b> from windows 10 powershell

```bash
# check your ubuntu version in wsl
lsb_release -a
pwd
df -h 
# windows folder
cd /mnt/c
sudo apt install htop
```

## Install and Test Redis

```bash
$ sudo apt-get update
$ sudo apt-get upgrade
$ sudo apt-get install redis-server
$ redis-cli -v

# restart
$ sudo service redis-server restart
$ sudo service redis-server stop

$ redis-cli
127.0.0.1:6379> set user:1 "TestUser"
127.0.0.1:6379> get user:1
```
## install npm in WSL ubuntu

```bash
$ sudo apt-get install curl
$ sudo curl -o- https://raw.githubusercontent.com/nvm-sh/nvm/v0.35.2/install.sh | bash
# exit your bash and reopen it
$ command -v nvm

# install node
$ nvm ls
$ nvm install node
$ nvm ls
$ node --version
$ npm --version
$ which node
$ which npm

# install angular cli
$ npm install -g @angular/cli

## Reference

- http://hanselman.com/windows10.
- https://github.com/nvm-sh/nvm
