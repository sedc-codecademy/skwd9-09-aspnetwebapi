import React, { useState } from "react";
import LoginForm from "./LoginForm";
import UserNotes from "./UserNotes";
import "./App.css";

function App() {
  const [userName, onUserNameChange] = useState("");
  const [password, onPasswordChange] = useState("");
  const [loggedUser, setLoggerUser] = useState(null);
  const [noteText, changeNoteText] = useState("");
  const [noteColor, changeNoteColor] = useState("");
  const [noteTag, changeNoteTag] = useState(1);
  const [notes, setUserNotes] = useState([]);

  const passwordChange = (e) => {
    onPasswordChange(e.target.value);
  };
  const userNameChange = (e) => {
    onUserNameChange(e.target.value);
  };
  const noteTextChange = (e) => {
    changeNoteText(e.target.value);
  };
  const noteTagChange = (e) => {
    changeNoteTag(e.target.value);
  };
  const noteColorChange = (e) => {
    changeNoteColor(e.target.value);
  };
  const logIn = async (e) => {
    e.preventDefault();
    const data = await fetch("https://localhost:44331/api/users/authenticate", {
      method: "POST",
      headers: {
        "content-type": "application/json",
      },
      body: JSON.stringify({
        username: userName,
        password: password,
      }),
    });
    const res = await data.json();
    setLoggerUser(res);
    setUserNotes(res.notes);
    localStorage.setItem("userToken", res.token);
  };
  const createNote = async (e) => {
    e.preventDefault();
    await fetch("https://localhost:44331/api/notes/addNewNote", {
      method: "POST",
      headers: {
        "content-type": "application/json",
        authorization: `Bearer ${localStorage.getItem("userToken")}`,
      },
      body: JSON.stringify({
        text: noteText,
        color: noteColor,
        tag: parseInt(noteTag),
        userId: loggedUser.id,
      }),
    });
    changeNoteText("");
    changeNoteTag(1);
    changeNoteColor("");
    const notesData = await fetch(
      `https://localhost:44331/api/notes/user/${loggedUser.id}`,
      {
        headers: {
          authorization: `Bearer ${localStorage.getItem("userToken")}`,
        },
      }
    );
    const notes = await notesData.json();
    setUserNotes(notes);
  };

  const deleteNote = async (noteId) => {
    try {
      await fetch(`https://localhost:44331/api/notes/deleteNote/${noteId}`, {
        method: "DELETE",
        headers: {
          authorization: `Bearer ${localStorage.getItem("userToken")}`,
        },
      });
      const updatedNotes = notes.filter((note) => note.id !== noteId);
      setUserNotes(updatedNotes);
    } catch (error) {
      alert(error.message);
    }
  };
  return (
    <>
      <div className="App">
        {loggedUser === null ? (
          <LoginForm
            onLogin={logIn}
            userName={userName}
            password={password}
            onPasswordChange={passwordChange}
            onUserNameChange={userNameChange}
          />
        ) : (
          <UserNotes
            notes={notes}
            noteText={noteText}
            onNoteTextChange={noteTextChange}
            noteColor={noteColor}
            onNoteColorChange={noteColorChange}
            noteTag={noteTag}
            onNoteTagChange={noteTagChange}
            createNote={createNote}
            onNoteDelete={deleteNote}
          />
        )}
      </div>
    </>
  );
}

export default App;
