<!-- section start -->
<!-- attr: { class:'slide-title', showInPresentation:true, hasScriptWrapper:true } -->
# Mobile Applications
##  Hybrid or Native?!
<div class="signature">
    <p class="signature-course">Mobile Applications for Windows</p>
    <p class="signature-initiative">Telerik Software Academy</p>
    <a href = "http://academy.telerik.com " class="signature-link">http://academy.telerik.com </a>
</div>

<!-- section start -->

# Table of Contents
- Mobile applications overview
  - Devices and platforms
  - Android, iOS, Windows Phone, Firefox OS and more
- Types of mobile applications
  - Web, Native and Hybrid applications Overview
- Means for Hybrid applications development

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper: true } -->
# Mobile Applications
##  What is a mobile application?

# Mobile Applications
- Mobile applications are **software applications running on mobile devices**
  - i.e. **tablets**, **smartphones** and other **mobile devices**
- Mobile applications are often available through app distribution platforms (stores)
  - Apple App Store, Google Play, Windows Phone Store, BlackBerry App World, etc…

# Mobile Platforms and Devices
- The most prominent platforms are as follows:
  - Apple iOS
  - Microsoft Windows
  - Google Android
  - Firefox OS (yet to come)
  - BlackBerry OS
  - webOS by LG (formally product of HP)
  - Nokia Symbian OS
  - Samsung Bada (stopped from development)
  - Tizen by Intel and Samsung

<!-- attr: {style: 'font-size: 0.9em'} -->
# Platforms Market Share 2015
- Mobile OS Market share for **Q3 2015** (August 2015) by [Gartner numbers](http://www.gartner.com/newsroom/id/3115517) and [IDC numbers](http://www.idc.com/prodserv/smartphone-os-market-share.jsp)

| Operating System | Share by Gartner | Share by IDC |
| ---------------- | ---------------- | ------------ |
| Android          | 82.2%            | 82.8%        |
| iOS              | 14.6%            | 13.9%        |
| Windows          | 2.5%             | 2.6%         |
| BlackBerry       | 0.3%             | 0.3%         |
| Others           | 0.4%             | 0.4%         |

<!-- section start -->

<!-- attr: { class:'slide-section'} -->
# Mobile Applications Development
##  Platforms and Tools

# Mobile Applications Development
- Platform, Tools and languages
  - **Windows**:
    - Tools: Visual Studio, Windows Phone SDK
    - Skills: C#, JavaScript, VB.NET, C++
  - **Android**:
    - Tools: Eclipse/Android Studio, Android Dev tools
    - Skills: Java and/or C++
  - **iOS**:
    - Tools: xCode, AppCode
    - Skills: Objective-C, Swift, C, C++

# Mobile Applications Development
- Platform, Tools and languages
  - **Firefox OS**:
    – Any text editor: ViM, Sublime Text, Atom.io
    - Skills: Web, HTML and JavaScript
  - **BlackBerry OS**:
    - Tools: QNX Momentics IDE
    - Java and/or C++
  - **Symbian OS**:
    - Tools: Carbide.c++ or Eclipse
    - Skills: C++ or Java

<!-- section start -->

<!-- attr: { class:'slide-section'} -->
# Types of Mobile Applications
##  Web, Hybrid and Native

# Types of Mobile Apps
- As the technology evolves, so does the power of Mobile apps
  - More and more companies introduce their own mobile apps
- Three common types of applications
  - **Web** mobile applications
  - **Native** mobile applications
  - **Hybrid** mobile applications

<!-- section start -->

<!-- attr: { class:'slide-section'} -->
# Web Mobile Applications

# Web Mobile Applications
- Web mobile apps are not real applications
  - They are **web sites** that have the **look and feel** of a mobile app
  - Developed in а web technology
    - ASP.NET, Node.js, Java SpringMVC, Django, etc...
- Web mobile apps run **in the browser**
  - Installed from an URL
  - They are actually a web site/application, working in chromeless browser

# Web Mobile Applications
- For security reasons **web mobile apps cannot use the full power** of the OS
  - APIs like Geolocation, File System and Camera are inaccessible
    - The users must **explicitly confirm the access** for some of the APIs, every time s/he opens the app
- Web mobile application are most suitable for informational applications and apps not using mobile functionality
  - Like a RSS application, news app

<!-- section start -->

<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true } -->
# Native Mobile Applications
##  Using the default technology

# Native Applications
- Native applications are applications developed for running on a specific OS
  - They run only on its operating system
- Native apps must be installed either using an **Application Store** (Google Play, App Store) or through an **external app installer**

# Native Applications
- Native apps have **full access to resources** of OS
  - Geolocation, File System, Accelerometer, etc.
  - The user still needs to confirm the access to device APIs
    - Yet, only once, at the installation of the app
- Native apps are developed on the platform and are hard to be ported to other platforms
  - iPhone apps with Objective-C/Swift
  - Android apps with Java
  - Windows Phone apps with C#, JavaScript, C++

# Native Applications
- Native apps are suitable when developing:
  - **Games**
    - The developer can use the device’s GPU
  - Apps with **complex processing**
    - The app must do a work of processing
  - Apps where **10 milliseconds slowdown is crucial**

<!-- section start -->

<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true } -->
# Hybrid Mobile Applications
##  Learning all Objective-C, Java and C# is not good enough?

# Hybrid Applications

- Hybrid apps are part native, part web apps
  - Yet they are neither
  - Also called cross-platform
- Hybrid apps are **like native apps**
  - They can be **published to an application store**
  - They can be **installed on the device**
  - They can use the **full power of the device**
- Hybrid apps are like **web apps**
  - Coded in web technologies like **HTML and JS**

# Hybrid Applications

- Hybrid applications **leverage the engine** of the **default browsers** for the platform
  - Safari mobile for iOS
  - Android browser for Android
  - IE10/IE11 mobile for Windows Phone 7 and Windows Phone 8
  - Edge for Windows 10
- The browser **engine renders the HTML** and **process the JavaScript locally** to the device
  - There is an abstraction layer, enabling the app to access device capabilities

<!-- attr: {style: 'font-size: 0.9em'} -->
# Hybrid Applications

- Hybrid applications run in a **native container** on a mobile device
  - The native container uses the browser engine to run the app
    - `UIWebView` for iOS
    - `WebView` for Android
    - `WebBrowser` in Windows Phone 8
  - This enables the app to use the device capabilities
- Hybrid application are a good choice when developing a Line-of-business application
  - Apps showing data
  - Games that do not have complex graphics and dynamics

# Hybrid Applications Structure

- Most of the default mobile browsers use WebKit-like rendering engine
  - That means iOS, Android, Blackberry, etc.
  - Windows Phone’s IE uses Trident engine
  - Windows Edge uses EdgeHTML engine
- That is why most hybrid applications can be tested on simulators, not only on emulators
  - i.e. running in a browser that is resized to fixed resolution and screen size

<!-- section start -->

<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true } -->
# Hybrid Apps Platforms
##  Different ways of creating hybrid apps

# Hybrid Apps Platforms
- Since the rise of HTML5 (2010) more and more hybrid application platforms surfaced
  - Apache Cordova (late PhoneGap)
  - Appcelerator Titanium
  - NativeScript by Telerik
  - Xamarin
  - And more
- Most hybrid app platforms targeted web developers with JavaScript skills
  - Since HTML is supported everywhere

# NativeScript by Telerik
- NativeScript is a platform for creating cross-platform native applications with JavaScript
  - Has its own JavaScript engine that interprets the JavaScript to native operations
  - Has almost very small performance hit on the app
  - The only drawback is bigger size of the application

# Apache Cordova
- Apache Cordova (late PhoneGap) is a platform for creating mobile applications using web technologies
  - The applications run on the most used platforms
    - iOS, Android, BlackBerry, Windows Phone, etc…
  - Applications run in a web view
- Apache Cordova was created by Nitobi Software, and was acquired by Adobe Systems in 2011

# Appcelerator Titanium
- Appcelerator Titanium is a product of Appcelerator Inc.
  - Use web technologies (like HTML and JS) to build cross-platform (hybrid) applications
  - Apps run on most platforms – Android, BlackBerry, iOS and Tizen
  - Applications run in a web view
- Titanium has its own IDE, called Titatinum Studio and simulators

# Xamarin
- Xamarin is a cross-mobile applications platform
  - Yet, it does not use web technologies
  - Xamarin now continues the development of the Mono platform
    - Mono, MonoTouch, and Mono for Android
  - Applications are developed using C# and .NET like platform (Mono)
  - Apps run on iOS, Android and Windows Phone

<!-- section start -->
<!-- attr: { id:'', class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
<!-- # Mobile Applications
## Questions -->
[link to our Forum](http://telerikacademy.com/Forum/Category/9/mobile-development)
