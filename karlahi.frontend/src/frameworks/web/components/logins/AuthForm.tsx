import * as React from "react";
import { useState } from "react";

interface IProps {
  accredit(id: string, pw: string): void;
  btnValue: string;
}

const AuthForm: React.FC<IProps> = (props) => {
  const { accredit, btnValue } = props;
  const [id, setId] = useState<string>("");
  const [pw, setPw] = useState<string>("");

  const handleChangeClientInfo = (
    event: React.ChangeEvent<HTMLInputElement>
  ): void => {
    const updateFnc = event.target.name === "id" ? setId : setPw;
    updateFnc(event.target.value);
  };

  const handleClickAccredit = () => {
    accredit(id, pw);
  };

  const handleKeyDownAccredit = (event: React.KeyboardEvent) => {
    if (event.key === "Enter") {
      accredit(id, pw);
    }
  };

  return (
    <div className="ui form">
      <div className="ui segment">
        <div className="field">
          <label htmlFor="id">Username</label>
          <input
            type="text"
            name="id"
            placeholder="Username"
            onChange={handleChangeClientInfo}
            value={id}
          />
        </div>
        <div className="field">
          <label htmlFor="pw">Password</label>
          <input
            type="password"
            name="pw"
            placeholder="Password"
            onChange={handleChangeClientInfo}
            onKeyDown={handleKeyDownAccredit}
            value={pw}
          />
        </div>
        <button
          className="ui button"
          type="button"
          onClick={handleClickAccredit}
        >
          Login
        </button>
      </div>
    </div>
  );
};

export default AuthForm;
