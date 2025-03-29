### How to regenerate every time 
(or not when you need to update the templates)

If you need to do a comparison:
1. Unhide the generated folder (in Another.csproj),
1. Compare two with three files, 
1. Make changes to the three file
1. When happy replicate the changes in the generator template
1. Delete the two file you expect to get modified to it'll be regenerated
1. Regenerate the files, rinse repeat and then finally...
1. When you're 100% happy reinstate the csproj to hide the generated folder.