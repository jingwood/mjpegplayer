# .NET MJPEG Player

A Windows application written in C# to receive and play the MJPEG stream video.

# The typical use case

1. Set up a motion program on Raspberry Pi to record video
2. Send MJPEG stream video from motion program
3. Receive and play the MJPEG stream video using this program

# Features

- Simple frameless windows form design
- Notification area tray
- Keep window on top during playing video
- Hotkeys to switch between different window size (x1, x2, x4 and free)
- Automatically adjust window size according to received MJPEG stream
- Support via HTTP proxy server
- Keep proxy server settings using simple encryption policy
- Worked with .NET 2.0 framework
- No 3rd-party software required

# System requirements

- The .NET framework is required to run this program. 
- The .NET framework may be prompted to be installed automatically at first time to run this program.

# Build Environment

- Visual Studio 2012 or higher
- .NET 2.0 or higher
