import React from "react";

const UserNotes = (props) => {
  const {
    notes,
    noteText,
    onNoteTextChange,
    noteColor,
    onNoteColorChange,
    noteTag,
    onNoteTagChange,
    createNote,
    onNoteDelete,
  } = props;
  return (
    <>
      <ul>
        {notes.map((note) => (
          <li>
            <p>Text: {note.text}</p>
            <p>Color: {note.color}</p>
            <button onClick={() => onNoteDelete(note.id)}>X</button>
          </li>
        ))}
      </ul>
      <div>
        <form onSubmit={createNote}>
          <div className="form-group">
            <label for="note-text">Note Text</label>
            <input
              type="text"
              className="form-control"
              id="note-text"
              placeholder="Enter note text"
              value={noteText}
              onChange={onNoteTextChange}
            />
          </div>
          <div className="form-group">
            <label for="note-color">Note Color</label>
            <input
              type="text"
              className="form-control"
              id="note-color"
              placeholder="Enter note color"
              value={noteColor}
              onChange={onNoteColorChange}
            />
          </div>

          <div className="form-group">
            <label for="note-tag">Note Tag</label>
            <input
              type="number"
              className="form-control"
              id="note-tag"
              placeholder="Enter note Tag"
              value={noteTag}
              onChange={onNoteTagChange}
              max={6}
              min={1}
            />
          </div>

          <button type="submit" className="btn btn-primary">
            Create Note
          </button>
        </form>
      </div>
    </>
  );
};

export default UserNotes;
