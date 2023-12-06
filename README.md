# Project705 - IBM 705 mainframe emulator

Creating the most realistic emulator of a vacuum tube mainframe in existence. Oh, and building a working replica of a groovy 1950's console.

## Why?

What would be coolest piece of furniture for a software developer's apartment? That's right, a fully working replica of an IBM 705 mainframe console from 1958. With 170 blinking lights, large tactile switches and buttons, this console the size of an office desk will make quite the statement.

![705 console](./Docs/Images/consoleWithLightsNarrow.jpg)

It's the sort of thing that'll spark conversation no matter the occasion, uses a decimal number system that's easy to explain and has soft flickering lights create the sensation of a camp fire at night, gently twinkling away as it (very slowly) computes.

Most importantly however, it'll be something to brighten the day of my little nieces when they come to visit, who'll love playing with the lights, buttons and switches.

## The machine
The goal is to emulate a complete IBM 705 II installation as it appeared in 1958. This includes the processor and most of its Input/Output devices. Emulation should be able to run original software unmodified and be both timing and cycle accurate. The emulator should also emulate physical behaviour as required, such as calculating the intensity of light emitted from each indicator blub at any given moment, since incandescent blubs change colour along a gradient depending on total power applied over time.

Only the console and console typewriter are intended to physically built, the rest, software emulated.

The list of devices to be emulated are:

* 705 II CPU, with 40,000 characters of memory
* 714 Card Reader*
* 722 Card Punch*
* 727 Magnetic Tape units*
* 734 Magnetic Drum Storage
* 782 Console and Typewriter
* 760 Record Storage and Control
* 730 Printer*
* 717 Printer*

*control units for these devices are only emulated as far as necessary for original software to run.

## Compatibility
The emulator and its associated tools are developed as modern .Net applications and so should be compatible across all major operating systems. Only Windows 11 is currently tested, as I haven't the time to test on multiple operating systems at the moment.

## Contributing
This is a personal project for now so contributions aren't currently accepted.

## License
This project, its tools and documentation are all under GPLv3. Third party documentation and photographs remain under their original licenses.