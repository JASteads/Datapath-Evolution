DragAndSnapEvent.cs -- 
	PURPOSE - Add this to the object that you want to drag around
	USAGE	- Drag the object to the desired DropLocation and release it.
		  The object should then snap to the DropLocation's origin point.
	
	NOTE	- There MUST be an existing DropLocationList to use this function. Have a
		  Level or test Level in mind before creating a DragAndSnapEvent

DropLocation.cs --
	PURPOSE - Add this to the object that you want another object to be dropped into
	USAGE	- Set the position of the drop location and its expected state. When a
		  draggable object is placed inside the region, its state will be set to
		  whatever the object's state is

DropLocationList.cs --
	PURPOSE - Add this to the Level object that will require objects to be placed in
		  a specific DropLocation. It also used for searching for a the right DropLocation
		  when a draggable object is released within its transform
	USAGE   - Create a list of DropLocation objects and pass it into the constructor.

* As always, please report any bugs or glitches if you encounter any