import React from "react";

//generate layout component using typescript
const Layout = (props: any) => {  
  return (
    <div className="layout">
      <div className="body-app">{props.children}</div>
    </div>
  );
};
