import React from "react";

//menu component using semantic-ui
const Navbar = () => {
  return (
    <div className="menu-bar">
      <div className="ui secondary pointing menu">
        <a className="item">
          <i className="home icon"></i>
          Home
        </a>
        <a className="item">
          <i className="block layout icon"></i>
          Topics
        </a>
        <div className="right menu">
          <div className="item">
            <div className="ui icon input">
              <input type="text" placeholder="Search..." />
              <i className="search link icon"></i>
            </div>
          </div>
          <a className="ui item">Log in</a>
          <a className="ui item">Sign Up</a>
        </div>
      </div>
    </div>
  );
}