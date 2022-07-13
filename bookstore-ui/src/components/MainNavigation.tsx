import React, { lazy } from "react";
import { Route, Switch } from "react-router-dom";
import BookList from "../pages/book-listing";
import { RoutePaths } from "../utils/enum";
import Cart from "../pages/cart";
import PrivateRoute from "./PrivateRoute";


//component lazy loading
// const Home = lazy(() => import("../pages/login/index"));
const Login = lazy(() => import("../pages/login/index"));
const Book = lazy(() => import("../pages/book/index"));
const Register = lazy(() => import("../pages/register"));

const AppRoutes: React.FC = () => {
  return (
    <Switch>
      <Route exact path={"/"} component={BookList} />
      <Route exact path={RoutePaths.Login} component={Login} />
      <Route exact path={RoutePaths.Register} component={Register} />
	  {/* <Route exact path={RoutePaths.BookListing} component={BookList} /> */}
	    <Route exact path={RoutePaths.Book} component={Book} />
			<PrivateRoute exact path={RoutePaths.Cart} component={Cart} />
    </Switch>
  );
};

export default AppRoutes;
