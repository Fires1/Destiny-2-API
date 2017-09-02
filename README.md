# Destiny 2 API Entities

A collection of automatically generated Entities taken from the [Destiny 2 API Documentation](https://github.com/Bungie-net/api/blob/master/openapi.json).

**Code is not formatted because code generation is hard.**

## How this works...sorta

This is my first attempt at an "object oriented" "code generator". It reads the openapi.json source(see above link), reads through it for only the information it *needs*, Converts the info into nice Lists then interates through it and using all that data it has saved, generates files. 

It works with $ref as well.

# Todo:

- [ ] Document code
- [ ] Clean up code
- [ ] Endpoint gen

## Why?

Because of DestinySharp...soon to be rewritten.
