namespace Telerik.Web.Mvc.UnitTest
{
    using System.Web.Routing;

    using Moq;
    using Xunit;

    public class NavigationItemAuthorizationTests
    {
        private readonly Mock<IControllerAuthorization> _controllerAuthorization;
        private readonly Mock<IUrlAuthorization> _urlAuthorization;

        private readonly NavigationItemAuthorization _authorization;

        public NavigationItemAuthorizationTests()
        {
            _controllerAuthorization = new Mock<IControllerAuthorization>();
            _urlAuthorization = new Mock<IUrlAuthorization>();

            _authorization = new NavigationItemAuthorization(_controllerAuthorization.Object, _urlAuthorization.Object);
        }

        [Fact]
        public void Default_constructor_should_not_throw_exception()
        {
            Assert.DoesNotThrow(() => new NavigationItemAuthorization());
        }

        [Fact]
        public void Should_return_correct_value_for_route()
        {
            Mock<INavigationItem> item = new Mock<INavigationItem>();

            item.SetupGet(i => i.RouteName).Returns("ProductList");

            _controllerAuthorization.Setup(authorization => authorization.IsAccessibleToUser(It.IsAny<RequestContext>(), It.IsAny<string>())).Returns(true);

            Assert.True(_authorization.IsAccessibleToUser(TestHelper.CreateRequestContext(), item.Object));
        }

        [Fact]
        public void Should_return_correct_value_for_controller_action()
        {
            Mock<INavigationItem> item = new Mock<INavigationItem>();

            item.SetupGet(i => i.ControllerName).Returns("Product");
            item.SetupGet(i => i.ActionName).Returns("Detail");

            _controllerAuthorization.Setup(authorization => authorization.IsAccessibleToUser(It.IsAny<RequestContext>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            Assert.True(_authorization.IsAccessibleToUser(TestHelper.CreateRequestContext(), item.Object));
        }

        [Fact]
        public void Should_return_correct_value_for_url()
        {
            Mock<INavigationItem> item = new Mock<INavigationItem>();

            item.SetupGet(i => i.Url).Returns("~/Faq");

            _urlAuthorization.Setup(authorization => authorization.IsAccessibleToUser(It.IsAny<RequestContext>(), It.IsAny<string>())).Returns(true);

            Assert.True(_authorization.IsAccessibleToUser(TestHelper.CreateRequestContext(), item.Object));
        }

        [Fact]
        public void Should_return_correct_value_for_empty()
        {
            Assert.True(_authorization.IsAccessibleToUser(TestHelper.CreateRequestContext(), new Mock<INavigationItem>().Object));
        }
    }
}