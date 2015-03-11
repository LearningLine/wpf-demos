# wpf-demos
What you will learn in this course

What will you learn?
Essential Windows Presentation Foundation provides hands-on experience with the latest in Microsoft Windows desktop UI technologies. Come and get familiar with the dynamic and creative application development that WPF enables. Learn how to best utilize WPF for both new projects as well as porting existing Windows Forms, MFC or traditional Win32 application over to this new platform. 

You'll get answers to these questions:
What are the main building blocks of a WPF application and how do I use them?
What is MVVM and how do I use it?
How can I cleanly separate my behavior, UI design and resources using XAML and data binding?
How do I create and use vector-based 2D graphic resources?
What are the new features in WPF 4.5?
How can I use subtle effects and animations to liven up my applications?
When do I use a UserControl vs. a Custom Control?
Course highlights

Use Visual Studio and Expression Blend together to build your user interface.
Integrate your visual designers with your developers to maximize their skills.
Properly design your architecture to take advantage of data binding.
Integrate other .NET technologies such as LINQ and XLINQ with WPF.
Customize the appearance of controls with styles and themes.
Learn current UI design patterns and how to apply them in your development.
Leverage existing components and code you already have with WPF.
Course outline and topics

This course covers Windows Presentation Foundation (WPF) and is intended for developers familiar with C# and .NET and with Windows UI development. It covers all versions of WPF and teaches developers how to properly use the technology to build advanced Windows client desktop applications. 

The module list covered includes: 

Day 1

Introduction
Windows Presentation Foundation is the new API for building user experiences on .NET. This module looks at the motivation behind WPF and its main features. We'll look at the primary tools and classes used to generate WPF applications and how a basic application fits together. 

Using XAML
In this module, we'll discuss how XAML allows for creation of UI independent of the procedural code and how WPF provides for a clean separation of code and UI. 

Managing Layout
WPF provides a powerful layout engine. In this module, you'll learn how to choose between the different built-in panels and how to create your own panel if the need arises. You'll also discover how to fine-tune the layout using margin, padding and alignments, and to provide special effects through transforms such as rotations and scaling. 

Day 2

Framework Architecture
In this module we will cover internal details of the framework classes - how WPF integrates with the Windows operating system, manages property values and how it ultimately renders visual elements onto the screen. 

Input Management
WPF includes a new input management architecture that allows elements to receive input from child controls more easily than previous technologies. In this module, we will examine the new input architecture and see the most effective ways to take advantage of it. You'll also learn about commands and how to consolidate event handlers for different types of controls. 

Organizing your Applications
WPF enables much tighter integration between developers and designers and in this module we will discuss a variety of techniques to make this process run more smoothly. We will also look at ways to structure our project by separating out designer assets using Expression Blend and creating a logical project structure making it easier to have different roles working on the application together without interference. 

In this module we will continue the discussion of integrating designers into the development workflow by examining the support for common property setters through WPF Styles. You will learn how to segregate common properties and store them into resources so they can be managed in a single location. We will also discuss how visual interactivity can be achieved using Triggers - a fundamental support feature we will use later in the course. 

Day 3

Data Binding: Basics
One of the most interesting features of WPF is its ability to present data quickly and effectively. This module explains how to connect basic data to the UI and the motivation and technology behind it. You will learn how to connect controls together, how to make your business objects "binding-aware" and how to provide type conversions for your binding expressions. 

Data Binding: Collections
In this module, you will continue the data binding exploration by examining how to provide visual information for your business objects through data templates and then how to manage collections of objects on the UI. Finally, you will learn how to customize the display of collections through sorting, filtering and grouping, and how to data bind to hierarchies of collections (parent/child). 

Model-View-ViewModel
In this module we will discuss the Model-View-ViewModel UI pattern which is useful in separating the UI and visualization from the procedural logic that drives it. We will look at how you can use this to structure your application to provide better testability as well as which roles will provide which features (model vs. view vs. viewmodel). 

Day 4

2D Graphics
In this module, you'll learn how to utilize the graphics support in WPF. First, you'll get an overview of the graphics capabilities of WPF: shapes and geometries. Then, you'll learn how to use Expression Blend to create custom shapes, fills and special effects such as opacity and reflections. 

Control Templates: Basics
A unique capability of WPF is the ability to override the drawing behavior of all of the built-in controls. In this module, you'll learn how to redefine the visual appearance of existing controls through Control Templates. Here we will look at doing a simple replacement - the Button and how to provide a new visualization as well as visual behavior using Triggers and the Visual State Manager (VSM). 

Control Templates: Moving Beyond the Button
In this module we will continue our examination of control templates by looking at more advanced and complicated controls such as ListBox, Sliders, Treeviews and Tab controls. You will learn the best practices to replacing the various supported templates to provide a completely new visualization while still maintaining the complete procedural behavior. 

Day 5
Building Custom Controls
This module covers building reusable controls through composition and inheritance and then looks at building a new control from scratch. You'll learn about providing default styles for your controls and integrating with the WPF theme system so your control changes its visual appearance when the operating system theme changes. 


Appendices

Controls

This module details most of the supplied controls in WPF. It shows how to create and use them from XAML as well as providing information on controls that are new. [Note this is intended to be a reference for students, not to be delivered in lecture form].


Mixing WPF with Other UI Technologies

WPF provides extensive support to exist side-by-side with legacy technologies and in this module we'll look at the various ways you might use WPF within existing Windows Forms applications. We will also look at the opposite - how to use legacy controls such as Windows Forms controls from within WPF applications. 

Deployment Options

In this module, you will explore deployment options for your WPF applications and be introduced to the XAML Browser application style of deployment. As part of that, you will learn how to work within the .NET security infrastructure to provide a rich client deployed over the Internet.


Managing Binary Resources

Applications commonly use images and other media to provide visual feedback to the user. In this module you will see how WPF manages binary resources--either by embedding the content into an assembly, or standalone sources intended to be consumed by the application.



Globalization

This module will examine the support in WPF for globalization. We will examine some of the pitfalls present today and how to use some free tools to make it easier to develop applications intended for non-US markets.


Navigation

This module covers the new navigation services of WPF and how to use them to build task-oriented applications or wizard-style pages. It also includes coverage of annotations and the history journal.


Documents and Printing

Adding rich document support to your applications is easy with WPF because it supports a full API for managing textually oriented content. This module explores this section of the WPF API and shows how to use the document support and then how to render it to a fixed format using the XML Paper Specification (XPS) support provided in the framework.


User Input Validation

This module examines the validation infrastructure and demonstrates how you can provide visual feedback to the user when the input is improperly formed. Several alternatives are discussed which build on the various features of the platform.

WPF Charting

The WPF Toolkit has several important controls which have been released out-of-band from the WPF core assemblies. One of these controls is the WPF Chart control which creates charting visualizations from data. This module explores this new feature of WPF and shows you how to generate dynamic pie, bar, line, scatter, and other charts using common data series.

DataBinding with Data Providers and XML 
In this module we examine ways of working with data that is not exposed through properties - but instead bound to methods of objects. We can turn these into bindable properties using the ObjectDataProvider support built into WPF. You will also see how to work with XML using the built-in XmlDataProvider and XLinq support added in WPF 3.5.

Performance Tuning and Diagnostics 
WPF is a completely new technology, built from the ground-up to allow you to create amazing new interactive experiences for your clients. In this module we'll look at some of the performance hot-spots developers commonly encounter when transitioning to WPF and what you can do about it. We'll also sample some of the tools provided to help you identify and isolate problems and finally we'll look at some ways to optimize your application so it runs smoothly.

Navigation
Some applications, such as ones oriented towards web users, are built out of a sequence of pages - each providing some form of UI to the user and providing some form of navigation between them. In this module, we will examine what WPF provides for in building composable page-based applications.

3D Graphics 
WPF provides a fairly consistent API for dealing with 3D objects in the 2D world. In this module we will examine the basics of 3D modeling and how to use those models in your applications to provide a more realistic experience for the user.

Pixel Shaders
One of the new features added in WPF 3.5 SP1 is hardware accelerated bitmap effects, called Pixel Shaders. Unlike the prior effects, these effects can be created by developers very easily and added to your visual tree to provide transitions and real-time per-pixel visual effects. This module examines this new feature and shows you how to build GPU based effects.

Advanced Layout and Custom Panels 
This module goes deeper into the layout system in WPF showing you how the two-pass layout system sizes and arranges elements on the screen and how you can leverage the framework to create custom panels to generate any layout style you can imagine.

Behaviors, Actions and Triggers with Blend 
Blend 3 formalizes the attached behavior pattern by introducing the System.Windows.Interactive namespace and behavior/action support in the Blend UI. This module will show you how this new support infrastructure works and how to create your own designer behaviors.

What's New in WPF 4.0 
WPF 4.0 has some subtle and not-so-subtle changes to the WPF technology stack which can improve performance and the visual quality of your applications. This module dives into those changes and shows you to take advantage of these changes in your existing or new WPF applications.

Introduction to Prism 
This module introduces you to PRISM (Composite Application Guidance) and how to use it to structure large WPF applications in a flexible, composed fashion.

Using the Adorner Layer 
This module briefly covers the adorner layer in WPF which can be used to provide visual effects over other elements. WPF uses this layer to provide decorations on top of other elements - such as selection or resize handles. You can take advantage of this in your code too by creating adorner decorators and this module explains how it all works.

More on Dependency Properties 
DependencyProperties are a core component of WPF which is used to implement a large number of new features. This module supplements the Framework Architecture module by diving deeper into Dependency Properties, how you create them, how they work, and various options to control them.

Animations
You have already seen the basics of the animation system as used by the Visual State Manager in Control Templates, this module expands on that knowledge - showing you how you can fine-tune storyboards, control them from code or XAML and create standalone animations.

Asynchronous Execution 
Making sure your application is robust and responsive often involves utilizing background threads to do long-running tasks, or receiving input on secondary threads when it is available. In this module we will look at the threading architecture of WPF and how to deal with the UI in the face of multiple threads.

What's New in WPF 4.5 
.NET 4.5 is offers some excellent new performance changes for WPF for typical LOB type applications. This module dives into those changes and shows you some of the new features you can take advantage of to increase your application performance, particularly for large data sets.

