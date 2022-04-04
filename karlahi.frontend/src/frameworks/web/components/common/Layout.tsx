import * as React from "react";

interface IChildrenProps {
  children?: React.ReactNode;
}

const Layout : React.FC<IChildrenProps> = (props: React.PropsWithChildren<IChildrenProps>) => {
  return <div>{props.children}</div>;
};

export default Layout;
