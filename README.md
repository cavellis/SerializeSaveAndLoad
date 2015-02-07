# SerializeSaveAndLoad

This is a quick Unity project that shows a few useful things you can do with the inspector to expose properties, so you can easily have all your game options in one place for quicker game balancing and testing. It also shows how to save and load these properties to and from a text file that's stored in the Assets.

<ul>
<li>How to alter the inspector to add a save button, a load button, and a text box with some info for the user.</li>
<li>How to pop up dialog boxes in the editor to let the user know a save or load is complete.</li>
<li>How to use [System.Serializable] to expose objects in lists in the inspector.</li>
<li>How to use JsonMember tag to include/exclude properties from being serialized</li>
<li>How to use the Tooltip tag to show tooltips when the user mouses over a property in the Inspector.</li>
<li>How to save and load the exposed public properties of an object instance, using JsonFx.</li>
