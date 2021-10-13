import React from "react";

const LoginForm = (props) => {
  const { onLogin, userName, password, onPasswordChange, onUserNameChange } =
    props;
  return (
    <form onSubmit={onLogin}>
      <div className="form-group">
        <label for="exampleInputEmail1">UserName</label>
        <input
          type="text"
          className="form-control"
          id="exampleInputEmail1"
          placeholder="Enter username"
          value={userName}
          onChange={onUserNameChange}
        />
      </div>
      <div className="form-group">
        <label for="exampleInputPassword1">Password</label>
        <input
          type="password"
          className="form-control"
          id="exampleInputPassword1"
          placeholder="Password"
          value={password}
          onChange={onPasswordChange}
        />
      </div>
      <button type="submit" className="btn btn-primary">
        Submit
      </button>
    </form>
  );
};

export default LoginForm;
