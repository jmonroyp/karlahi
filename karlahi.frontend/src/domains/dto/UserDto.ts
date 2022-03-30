export interface IUserParams {
  id: string;
  pw: string;
}

export interface IUserDto {
  readonly username: string;
  readonly password: string;
}

class UserDto implements IUserDto {
  readonly username: string;
  readonly password: string;

  constructor(param: IUserParams) {
    this.username = param.id;
    this.password = param.pw;
  }
}

export default UserDto;
