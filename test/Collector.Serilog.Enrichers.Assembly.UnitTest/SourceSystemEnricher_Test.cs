﻿namespace Collector.Serilog.Enrichers.Assembly.UnitTest
{
    using System.Reflection;

    using Collector.Serilog.Enrichers.Assembly;

    using global::Serilog;
    using global::Serilog.Events;

    using NUnit.Framework;

    [TestFixture]
    public class SourceSystemEnricher_Test
    {
        [Test]
        public void When_using_the_generic_version_the_assembly_name_of_the_type_is_used()
        {
            LogEvent logEvent = null;
            var logger = new LoggerConfiguration()
                .Enrich.With<SourceSystemEnricher<SourceSystemEnricher_Test>>()
                .WriteTo.Sink(new DelegatingSink(e => logEvent = e))
                .CreateLogger();

            logger.Information("Test log");

            Assert.AreEqual("Serilog.Enrichers.Assembly.UnitTest", ((ScalarValue)logEvent.Properties["SourceSystem"]).Value);
        }

        [Test]
        public void It_takes_the_assembly_name_from_the_supplied_assembly()
        {
            LogEvent logEvent = null;
            var logger = new LoggerConfiguration()
                .Enrich.With(new SourceSystemEnricher(typeof(global::Serilog.Context.LogContext).GetTypeInfo().Assembly))
                .WriteTo.Sink(new DelegatingSink(e => logEvent = e))
                .CreateLogger();

            logger.Information("Test log");

            Assert.AreEqual("Serilog", ((ScalarValue)logEvent.Properties["SourceSystem"]).Value);
        }

        [Test]
        public void It_uses_the_supplied_name_if_sent_as_string()
        {
            LogEvent logEvent = null;
            var logger = new LoggerConfiguration()
                .Enrich.With(new SourceSystemEnricher("My String"))
                .WriteTo.Sink(new DelegatingSink(e => logEvent = e))
                .CreateLogger();

            logger.Information("Test log");

            Assert.AreEqual("My String", ((ScalarValue)logEvent.Properties["SourceSystem"]).Value);
        }
    }
}